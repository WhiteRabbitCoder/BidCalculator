<template>
  <n-card title="Bid Calculator" size="large" class="max-w-md mx-auto mt-12">
    <n-form>
      <n-form-item label="Price">
        <n-input-number
          v-model:value="price"
          :min="1"
          placeholder="Enter vehicle price"
          style="width: 100%"
        />
      </n-form-item>

      <n-form-item label="Type">
        <n-select
          v-model:value="type"
          :options="[
            { label: 'Common', value: 'Common' },
            { label: 'Luxury', value: 'Luxury' },
          ]"
          placeholder="Select type"
        />
      </n-form-item>
    </n-form>

    <FeeBreakdown v-if="result" :data="result" class="mt-6" />
  </n-card>
</template>

<script setup>
import { ref, watch } from "vue";
import { calculateBid } from "../services/api";
import FeeBreakdown from "./FeeBreakdown.vue";
import { useMessage } from "naive-ui";

const message = useMessage();
const price = ref(null);
const type = ref("");
const result = ref(null);
const loading = ref(false);
let timeout = null;

// 👀 Watch both fields and auto-send when changed
watch([price, type], ([newPrice, newType]) => {
  clearTimeout(timeout);
  if (!newPrice || !newType) {
    result.value = null;
    return;
  }

  timeout = setTimeout(async () => {
    try {
      loading.value = true;
      result.value = await calculateBid({
        price: newPrice,
        type: newType,
      });
    } catch (err) {
      message.error("Error calculating bid");
      result.value = null;
    } finally {
      loading.value = false;
    }
  }, 500); // 🕒 0.5s delay to avoid overloading the backend
});
</script>

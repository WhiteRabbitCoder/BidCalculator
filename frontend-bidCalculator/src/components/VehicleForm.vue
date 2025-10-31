<template>
  <div class="bid-calculator-container">
    <div class="header-section">
      <h1 class="calculator-title">Bid Calculator</h1>
      <p class="calculator-subtitle">Calculate your vehicle bid with precision</p>
    </div>
    
    <div class="calculator-layout">
      <!-- Input Section -->
      <n-card 
        title="Input Data" 
        size="large" 
        class="input-card"
        :bordered="false"
      >
        <n-form>
          <n-form-item label="Price">
            <n-input-number
              v-model:value="price"
              :min="1"
              placeholder="Enter vehicle price"
              style="width: 100%"
              size="large"
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
              size="large"
            />
          </n-form-item>

          <n-space v-if="loading" justify="center" class="mt-4">
            <n-spin size="small" />
            <span class="loading-text">Calculating...</span>
          </n-space>
        </n-form>
      </n-card>

      <!-- Result Section -->
      <n-card 
        title="Result" 
        size="large" 
        class="result-card"
        :bordered="false"
      >
        <FeeBreakdown v-if="result" :data="result" />
        <n-empty
          v-else
          description="Enter price and type to see results"
          class="empty-state"
        />
      </n-card>
    </div>
  </div>
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

// Watch both fields and auto-send when changed
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
  }, 500);
});
</script>

<style scoped>
.bid-calculator-container {
  max-width: 1400px;
  margin: 0 auto;
  padding: 3rem 1.5rem;
  background: #f8fafc;
  min-height: 100vh;
}

.header-section {
  text-align: center;
  margin-bottom: 3rem;
}

.calculator-title {
  font-size: 2.75rem;
  font-weight: 600;
  color: #1e293b;
  margin-bottom: 0.5rem;
  letter-spacing: -0.02em;
}

.calculator-subtitle {
  font-size: 1.125rem;
  color: #64748b;
  font-weight: 400;
}

.calculator-layout {
  display: grid;
  grid-template-columns: 1fr;
  gap: 2rem;
  align-items: start;
}

/* Desktop layout: two columns */
@media (min-width: 768px) {
  .calculator-layout {
    grid-template-columns: 1fr 1fr;
  }
}

.input-card,
.result-card {
  background: white;
  border-radius: 16px;
  box-shadow: 0 1px 3px rgba(0, 0, 0, 0.05), 0 1px 2px rgba(0, 0, 0, 0.03);
  transition: box-shadow 0.3s ease;
  border: 1px solid #e2e8f0;
}

.input-card:hover,
.result-card:hover {
  box-shadow: 0 4px 12px rgba(0, 0, 0, 0.08), 0 2px 4px rgba(0, 0, 0, 0.04);
}

:deep(.n-card-header) {
  background: linear-gradient(to right, #3b82f6, #60a5fa);
  color: white;
  font-weight: 500;
  font-size: 1.125rem;
  padding: 1.25rem 1.75rem;
  border-radius: 16px 16px 0 0;
  letter-spacing: 0.01em;
}

:deep(.n-card__content) {
  padding: 2rem 1.75rem;
}

:deep(.n-form-item) {
  margin-bottom: 1.5rem;
}

:deep(.n-form-item-label) {
  font-weight: 500;
  color: #334155;
  font-size: 0.95rem;
  margin-bottom: 0.5rem;
}

:deep(.n-input-number),
:deep(.n-select) {
  border-color: #cbd5e1;
  border-radius: 8px;
}

:deep(.n-input-number:hover),
:deep(.n-select:hover) {
  border-color: #94a3b8;
}

:deep(.n-input-number:focus),
:deep(.n-input-number.n-input-number--focus),
:deep(.n-select:focus) {
  border-color: #3b82f6;
  box-shadow: 0 0 0 3px rgba(59, 130, 246, 0.08);
}

:deep(.n-input__input-el),
:deep(.n-base-selection-label) {
  color: #1e293b;
}

:deep(.n-input__placeholder),
:deep(.n-base-selection-placeholder) {
  color: #94a3b8;
}

.loading-text {
  color: #3b82f6;
  font-weight: 500;
  font-size: 0.95rem;
}

.empty-state {
  padding: 4rem 1rem;
}

:deep(.n-empty__icon) {
  color: #cbd5e1;
}

:deep(.n-empty__description) {
  color: #64748b;
  font-size: 0.95rem;
  font-weight: 400;
}

:deep(.n-spin__icon) {
  color: #3b82f6;
}

/* Mobile optimization */
@media (max-width: 767px) {
  .bid-calculator-container {
    padding: 2rem 1rem;
  }

  .calculator-title {
    font-size: 2rem;
  }

  .calculator-subtitle {
    font-size: 1rem;
  }

  .header-section {
    margin-bottom: 2rem;
  }

  .calculator-layout {
    gap: 1.5rem;
  }

  :deep(.n-card-header) {
    font-size: 1rem;
    padding: 1rem 1.25rem;
  }

  :deep(.n-card__content) {
    padding: 1.5rem 1.25rem;
  }
}

/* Tablet optimization */
@media (min-width: 768px) and (max-width: 1023px) {
  .calculator-title {
    font-size: 2.5rem;
  }

  .calculator-subtitle {
    font-size: 1.0625rem;
  }
}
</style>
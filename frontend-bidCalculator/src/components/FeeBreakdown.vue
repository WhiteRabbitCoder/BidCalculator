<template>
  <n-card title="Fee Breakdown">
    <n-descriptions bordered column="1">
      <n-descriptions-item label="Buyer Fee">
        {{ formatCurrency(data.buyerFee) }}
      </n-descriptions-item>
      <n-descriptions-item label="Special Fee">
        {{ formatCurrency(data.specialFee) }}
      </n-descriptions-item>
      <n-descriptions-item label="Association Fee">
        {{ formatCurrency(data.associationFee) }}
      </n-descriptions-item>
      <n-descriptions-item label="Storage Fee">
        {{ formatCurrency(data.storageFee) }}
      </n-descriptions-item>
      <n-descriptions-item label="Total Fees">
        <strong>{{ formatCurrency(data.totalFees) }}</strong>
      </n-descriptions-item>
      <n-descriptions-item label="Final Bid Total">
        <strong style="color:#007bff">{{ formatCurrency(data.bidTotal) }}</strong>
      </n-descriptions-item>
    </n-descriptions>
  </n-card>
</template>

<script setup>
const props = defineProps({
  data: Object,
});

const formatCurrency = (value) =>
  value.toLocaleString("en-US", { style: "currency", currency: "USD" });
</script>

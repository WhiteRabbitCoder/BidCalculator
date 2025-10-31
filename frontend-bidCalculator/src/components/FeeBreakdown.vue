<template>
  <div class="breakdown">
    <h3>Fee Breakdown</h3>
    <ul>
      <li>Buyer Fee: {{ data.buyerFee }}</li>
      <li>Special Fee: {{ data.specialFee }}</li>
      <li>Association Fee: {{ data.associationFee }}</li>
      <li>Storage Fee: {{ data.storageFee }}</li>
      <li><strong>Total: {{ data.total }}</strong></li>
    </ul>
  </div>
</template>

<script setup>
defineProps({ data: Object })
</script>

<style scoped>
.breakdown {
  background: #f9f9f9;
  padding: 1rem;
  border-radius: 8px;
}
ul {
  list-style: none;
  padding: 0;
}
li {
  margin-bottom: 0.5rem;
}
</style>

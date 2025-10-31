<template>
  <div class="form">
    <h2>Bid Calculator</h2>
    <form @submit.prevent="calculate">
      <div>
        <label>Price:</label>
        <input type="number" v-model="vehicle.price" required />
      </div>
      <div>
        <label>Type:</label>
        <select v-model="vehicle.type">
          <option value="Common">Common</option>
          <option value="Luxury">Luxury</option>
        </select>
      </div>
      <button type="submit">Calculate</button>
    </form>

    <FeeBreakdown v-if="result" :data="result" />
  </div>
</template>

<script setup>
import { ref } from 'vue'
import axios from 'axios'
import FeeBreakdown from './FeeBreakdown.vue'

const vehicle = ref({ price: 0, type: 'Common' })
const result = ref(null)

async function calculate() {
  try {
    const res = await axios.post('http://localhost:5088/api/calculate', vehicle.value)
    result.value = res.data
  } catch (err) {
    console.error(err)
    alert('Something went wrong.')
  }
}
</script>

<style scoped>
.form {
  max-width: 400px;
  margin: 40px auto;
  display: flex;
  flex-direction: column;
  gap: 1rem;
}
input, select, button {
  width: 100%;
  padding: 8px;
}
</style>

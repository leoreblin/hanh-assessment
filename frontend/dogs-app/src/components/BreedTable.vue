<template>
  <div>
    <div class="filter">
      <input
        type="text"
        v-model="breedName"
        @input="onFilterChange"
        placeholder="Filter by breed name"
      />
    </div>

    <table>
      <thead>
        <tr>
          <th>Breed Name</th>
          <th>Description</th>
          <th>Life Range</th>
          <th>Male Weight Range</th>
          <th>Female Weight Range</th>
          <th>Hypoallergenic</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="breed in breeds" :key="breed.id">
          <td>{{ breed.breedName }}</td>
          <td>{{ breed.breedDescription }}</td>
          <td>{{ breed.lifeRange.min }} - {{ breed.lifeRange.max }} years</td>
          <td>{{ breed.maleWeightRange.min }} - {{ breed.maleWeightRange.max }} kg</td>
          <td>{{ breed.femaleWeightRange.min }} - {{ breed.femaleWeightRange.max }} kg</td>
          <td>{{ breed.hypoallergenic ? 'Yes' : 'No' }}</td>
        </tr>
      </tbody>
    </table>

    <div class="pagination">
      <button @click="goToPage(1)" :disabled="totalPages == 0 || currentPage == 1">First</button>
      <button @click="goToPage(currentPage - 1)" :disabled="currentPage <= 1">Previous</button>
      <span>Page {{ currentPage }} of {{ totalPages }}</span>
      <button @click="goToPage(currentPage + 1)" :disabled="currentPage >= totalPages">Next</button>
      <button @click="goToPage(totalPages)" :disabled="totalPages == 1 || currentPage == totalPages">Last</button>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref, onMounted } from 'vue';
import { fetchDogsBreeds } from '../services/DogApiService';
import { Breed } from '../models/Breed';
import { PaginatedResponse } from '../shared/PaginatedResponse'

export default defineComponent({
  name: 'BreedTable',
  setup() {
    const breeds = ref<Breed[]>([]);
    const breedName = ref('');
    const currentPage = ref(1);
    const totalPages = ref(1);
    const totalCount = ref(0);
    const pageSize = ref(10);

    const fetchBreeds = async () => {
      const response: PaginatedResponse<Breed> = await fetchDogsBreeds(
        currentPage.value,
        pageSize.value,
        breedName.value
      );
      breeds.value = response.items;
      totalPages.value = response.totalPages;
      totalCount.value = response.totalCount;
    };

    const onFilterChange = () => {
      currentPage.value = 1;
      fetchBreeds();
    };

    const goToPage = (page: number) => {
      if (page >= 1 && page <= totalPages.value) {
        currentPage.value = page;
        fetchBreeds();
      }
    };

    onMounted(fetchBreeds);

    return {
      breeds,
      breedName,
      currentPage,
      totalPages,
      totalCount,
      pageSize,
      fetchBreeds,
      onFilterChange,
      goToPage,
    };
  },
});
</script>

<style scoped>
.filter {
  margin-bottom: 10px;
}

table {
  width: 100%;
  border-collapse: collapse;
}

th, td {
  padding: 8px;
  text-align: left;
  border: 1px solid #ddd;
}

.pagination {
  margin-top: 20px;
  display: flex;
  justify-content: center;
  align-items: center;
}

button {
  padding: 5px 10px;
  margin: 0 5px;
  cursor: pointer;
}

button:disabled {
  cursor: not-allowed;
  opacity: 0.5;
}
</style>

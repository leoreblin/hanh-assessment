<template>
  <div id="app">
    <BreedTable />
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import BreedTable from './components/BreedTable.vue';

@Options({
  components: {
    BreedTable,
  },
})
export default class App extends Vue {}
</script>


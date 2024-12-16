import { createRouter, createWebHistory, RouteRecordRaw } from 'vue-router';
import BreedTable from '../components/BreedTable.vue';

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    redirect: '/breeds',
  },
  {
    path: '/breeds',
    name: 'BreedTable',
    component: BreedTable,
  },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;

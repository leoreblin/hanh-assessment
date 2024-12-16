import { createApp } from 'vue'
import App from './App.vue';
import 'vuetify/styles';
import { createVuetify } from 'vuetify';

import router from './router';

const vuetify = createVuetify();

const app = createApp(App);

app.use(router);
app.use(vuetify);
app.mount('#app');

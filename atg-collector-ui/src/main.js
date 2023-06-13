import Vue from 'vue'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.css'

Vue.use(Vuetify);

const vuetify = new Vuetify({
    theme: {
        // Customize your theme here
    }
});

new Vue({
    // ...
  }).$mount('#app');
import Vue from 'vue';
import App from './App.vue';

/*--------- Bootstrap Stuff ---------*/
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
// This imports <b-card> along with all the <b-card-*> sub-components as a plugin:
import { CardPlugin } from 'bootstrap-vue'
Vue.use(CardPlugin)
// This imports <b-card> along with all the <b-card-*> sub-components as a plugin:
import { ButtonPlugin } from 'bootstrap-vue'
Vue.use(ButtonPlugin)
/*--------- /Bootstrap Stuff ---------*/


/*--------- Router Stuff ---------*/
import VueRouter from 'vue-router'

Vue.use(VueRouter)
/*--------- /Router Stuff ---------*/


Vue.config.productionTip = true;

new Vue({
    render: h => h(App)
}).$mount('#app');

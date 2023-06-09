<template>
  <div id="app">
    <BasicChart :data="chartData"></BasicChart>
  </div>
</template>

<script>
import BasicChart from './components/BasicChart.vue';
import axios from 'axios';

export default {
  name: 'App',
  components: {
    BasicChart,
  },
  data() {
    return {
      chartData: {},
    };
  },
  methods: {
    getData(option) {
      axios.get(`https://localhost:7251/api/data/${option}`)
        .then(response => {
          this.chartData = response.data;
        })
        .catch(error => {
          console.error(error);
        });
    },
  },
};
</script>






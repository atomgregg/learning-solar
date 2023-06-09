<template>
    <div>
      <Line
        v-if="loaded"
        :options="chartOptions"
        :data="chartData"
        :width="400"
        :height="800" />
    </div>
  </template>
  
  <script>
  import { Line } from 'vue-chartjs'
  import axios from 'axios';
  import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale, PointElement, LineElement } from 'chart.js'
  
  ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale, PointElement, LineElement);
  
  export default {
    name: 'LineChart',
    components: {
      Line
    },
    data: () => ({
      loaded: false,
      chartData: null,
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false
      }
    }),
    async mounted () {
      this.loaded = false;
  
      var colors = ['green', 'blue', 'yellow'];
  
      try {
        axios
          .get('https://localhost:7251/api/data/recent')
          .then((response) => {
            const labels = [...new Set(response.data.map((item) => item.tstamp))];
            const datasets = [];
  
            // group data by rowKey
            const groupedData = response.data.reduce((acc, item, idx) => {
              if (!acc[item.rowKey]) {
                acc[item.rowKey] = {
                  label: item.rowKey,
                  data: [],
                  borderWidth: 1,
                  fill: false,
                  borderColor: colors[idx]
                };
              }
              acc[item.rowKey].data.push(item.intValue);
              return acc;
            }, {});
  
            // transform grouped data to datasets format
            for (const key in groupedData) {
              datasets.push(groupedData[key]);
            }
            
            // set the data
            this.chartData = {labels, datasets };
            this.loaded = true;
        })
        .catch((error) => {
          console.error(error);
        });
      } catch (e) {
        console.error(e)
      }
    }
    };
  </script>
  
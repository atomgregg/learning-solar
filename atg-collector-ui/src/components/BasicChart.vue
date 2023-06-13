<template>
  <div class="button-container">
    <button :class="{'active': selectedOption === 'today'}" @click="getData('today')">Today</button>
    <button :class="{'active': selectedOption === 'yesterday'}" @click="getData('yesterday')">Yesterday</button>
    <button :class="{'active': selectedOption === 'recent'}" @click="getData('recent')">Recent</button>
    <button :class="{'active': selectedOption === 'trend'}" @click="getData('trend')">Trend</button>
  </div>

  <div>
    <Line
      v-if="loaded"
      :options="chartOptions"
      :data="chartData"
      :width="400"
      :height="800"
    />
  </div>
</template>

<script>
import { Line } from 'vue-chartjs';
import { ref, onMounted } from 'vue';
import { Chart as ChartJS, Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale, PointElement, LineElement } from 'chart.js'
import axios from 'axios';

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale, PointElement, LineElement);

export default {
  name: 'BasicChart',
  components: {
    Line,
  },
  setup() {
    const loaded = ref(false);
    const chartData = ref({});
    const chartOptions = {
      responsive: true,
      maintainAspectRatio: false,
      plugins: {
        legend: {
          position: 'top',
          align: 'end',
          labels: {
            boxWidth: 12,
            boxHeight: 2,
            padding: 10,
            font: {
              size: 12,
              weight: 'bold'
            }
          }
        }
      },
      elements: {
        point: {
          radius: 0, // Set the radius to 0 to hide the dots
        },
      },
    };
    const selectedOption = ref('yesterday');
    const colors = ['#007bff', '#28a745', '#ffc107', '#dc3545'];

    const getData = async (option) => {
      selectedOption.value = option;
      try {
        const response = await axios.get(`https://localhost:7251/api/data/${option}`);
        const data = response.data;

        const labels = [...new Set(data.map((item) => item.tstamp))];
        const datasets = [];

        const groupedData = data.reduce((acc, item, idx) => {
          if (!acc[item.rowKey]) {
            acc[item.rowKey] = {
              label: item.rowKey,
              data: [],
              borderWidth: 1,
              fill: false,
              borderColor: colors[idx % colors.length],
            };
          }
          acc[item.rowKey].data.push(item.intValue);
          return acc;
        }, {});

        for (const key in groupedData) {
          datasets.push(groupedData[key]);
        }

        chartData.value = {
          labels,
          datasets,
        };
        loaded.value = true;
      } catch (error) {
        console.error(error);
      }
    };

    onMounted(async () => {
      try {
        await getData('yesterday');
      } catch (error) {
        console.error(error);
      }
    });

    return {
      loaded,
      chartData,
      chartOptions,
      getData,
      selectedOption,
    };
  },
};
</script>

<style>
.button-container button.active {
  background-color: #007bff;
  color: #fff;
}
.button-container {
  margin-top: 10px;
}
.button-container button {
  margin-right: 5px;
  border: none;
  border-radius: 4px;
  padding: 8px 12px;
  background-color: #f7f7f7;
  color: #333;
  cursor: pointer;
  transition: background-color 0.3s;
}
.button-container button:hover {
  background-color: #e9e9e9;
}
</style>
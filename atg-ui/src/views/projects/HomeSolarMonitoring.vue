<template>
  <v-tabs v-model="tab" align-tabs="start" stacked>
    <v-tab value="about">About</v-tab>
    <v-tab value="dashboard">Dashboard</v-tab>
  </v-tabs>
  <v-window v-model="tab">
    <v-window-item value="about">
      <About></About>
    </v-window-item>
    <v-window-item value="dashboard">
      <Dashboard></Dashboard>
    </v-window-item>
  </v-window>
</template>

<script setup>
import About from "@/components/projects/homesolarmonitoring/About.vue";
import Dashboard from "@/components/projects/homesolarmonitoring/Dashboard.vue";
</script>

<script>
export default {
  data: () => ({
    tab: null,
  }),
};
</script>
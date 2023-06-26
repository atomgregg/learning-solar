<template>
  <v-responsive>
    <v-row no-gutters justify="center" class="mb-6">
      <v-col cols="8" offset="2">
        <v-sheet class="pa-2 ma-2">
          <v-tabs v-model="tab" align-tabs="start" stacked>
            <v-tab value="about">About</v-tab>
            <v-tab value="dashboard">Dashboard</v-tab>
          </v-tabs>
          <v-window v-model="tab">
            <v-window-item value="about">
              <v-container fluid>
                <About></About>
              </v-container>
            </v-window-item>
            <v-window-item value="dashboard">
              <v-container fluid>
                <Dashboard></Dashboard>
              </v-container>
            </v-window-item>
          </v-window>
        </v-sheet>
      </v-col>
    </v-row>
  </v-responsive>
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
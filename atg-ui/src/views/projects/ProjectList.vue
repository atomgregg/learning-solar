<template>
  <v-responsive v-if="mobile">
    <v-row>
      <v-col cols="12"><SolarMonitoring /></v-col>
    </v-row>
  </v-responsive>
  <v-responsive v-else>
    <v-row>
      <v-col cols="4"><SolarMonitoring /></v-col>
      <v-col cols="4"></v-col>
      <v-col cols="4"></v-col>
    </v-row>
  </v-responsive>
</template>

<script setup>
import SolarMonitoring from "@/components/projects/homesolarmonitoring/ListItem.vue";

import { useDisplay } from "vuetify";
const { mobile } = useDisplay();
</script>
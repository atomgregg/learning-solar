<template>
  <v-responsive v-if="mobile">
    <v-row>
      <v-col cols="12"><CareerPivot /></v-col>
    </v-row>
    <v-row no-gutters justify="center" class="mb-6">
      <v-col cols="12"><RaspberryPiWifi /></v-col>
    </v-row>
  </v-responsive>
  <v-responsive v-else>
    <v-row>
      <v-col cols="4"><CareerPivot /></v-col>
      <v-col cols="4"><RaspberryPiWifi /></v-col>
      <v-col cols="4"> </v-col>
    </v-row>
  </v-responsive>
</template>

<script setup>
import CareerPivot from "@/components/blogs/202306_CareerPivot_List.vue";
import RaspberryPiWifi from "@/components/blogs/202306_RaspberryPi_Wifi_List.vue";

import { useDisplay } from "vuetify";
const { mobile } = useDisplay();
</script>
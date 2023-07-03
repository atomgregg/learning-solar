<template>
  <v-main>
    <v-responsive v-if="mobile">
      <v-row no-gutters justify="center" class="mb-6">
        <v-col cols="10" offset="1">
          <router-view />
        </v-col>
      </v-row>
    </v-responsive>
    <v-responsive v-else justify="center">
      <v-row no-gutters justify="center" class="mb-6">
        <v-col cols="8" offset="2">
          <router-view />
        </v-col>
      </v-row>
    </v-responsive>
  </v-main>
</template>

<script setup>
import { useDisplay } from "vuetify";
const { mobile } = useDisplay();
</script>
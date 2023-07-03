<template>
  <v-responsive v-if="mobile" class="pa-2 ma-2">
    <v-row>
      <v-col cols="12">
        <ContactDetails />
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12">
        <AboutMe />
      </v-col>
    </v-row>
  </v-responsive>
  <v-responsive v-else>
    <v-row no-gutters justify="center" class="mb-6">
      <v-col cols="4" offset="2">
        <v-sheet class="pa-2 ma-2">
          <AboutMe />
        </v-sheet>
      </v-col>
      <v-col cols="4">
        <v-sheet class="pa-2 ma-2">
          <ContactDetails />
        </v-sheet>
      </v-col>
    </v-row>
  </v-responsive>
</template>

<script setup>
import { useDisplay } from "vuetify";
const { mobile } = useDisplay();

import ContactDetails from "@/components/aboutme/ContactDetails.vue";
import AboutMe from "@/components/aboutme/AboutMe.vue";
</script>

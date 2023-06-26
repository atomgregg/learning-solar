<template>
  <v-responsive>
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
import ContactDetails from "@/components/aboutme/ContactDetails.vue";
import AboutMe from "@/components/aboutme/AboutMe.vue";
</script>

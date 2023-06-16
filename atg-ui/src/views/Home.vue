<template>
  <v-responsive class="align-center text-left fill-height">
    <v-row no-gutters>
      <v-col>
        <v-sheet class="pa-2 ma-2">
          <AboutMe />
        </v-sheet>
      </v-col>
      <v-col>
        <v-sheet class="pa-2 ma-2">
          <ContactDetails />
        </v-sheet>
      </v-col>
    </v-row>
  </v-responsive>
</template>

<script setup>
  import ContactDetails from '@/components/aboutme/ContactDetails.vue'
  import AboutMe from '@/components/aboutme/AboutMe.vue'
</script>

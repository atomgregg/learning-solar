<template>
  <v-card>
    <v-layout>
      <default-bar />

      <default-nav />

      <default-view />
    </v-layout>
  </v-card>
</template>

<script setup>
  import DefaultBar from './AppBar.vue'
  import DefaultNav from './LeftNav.vue'
  import DefaultView from './View.vue'
</script>
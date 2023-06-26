<template>
  <v-responsive>
    <v-row no-gutters justify="center" class="mb-6">
      <v-col cols="8" offset="2">
        <v-sheet class="pa-2 ma-2">
          <ComingSoon></ComingSoon>
        </v-sheet>
      </v-col>
    </v-row>
  </v-responsive>
</template>
  
<script setup>
import ComingSoon from "@/components/blogs/ComingSoon.vue";
</script>
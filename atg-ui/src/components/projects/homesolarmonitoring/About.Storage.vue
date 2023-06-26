<template>
  <v-card width="300" class="ma-4">
    <v-img
      height="200"
      src="@/assets/projects/about-storage.png"
      cover
      class="text-white"
    >
      <v-toolbar color="rgba(0, 0, 0, 0)" theme="dark">
        <v-toolbar-title class="text-h6"> Data Storage </v-toolbar-title>
      </v-toolbar>
    </v-img>

    <v-card-subtitle class="pt-4">
      #postgresql, #docker, #persistent-store
    </v-card-subtitle>

    <v-card-text>
      <p>
        The store is a PostgreSQL database run within a container, receiving a
        volume in the docker run command so the data is persistent across
        container restarts.
      </p>
      <p class="pt-2">
        Initially I populated the database with a generated data set from a SQL
        insert statement that ChatGPT helped me to formulate.
      </p>
      <p class="pt-2">
        In the next version we will have live data, and you quickly see that I
        need a new inverter..
      </p>
    </v-card-text>
  </v-card>
</template>

<script>
export default {
  data: () => ({
    show: false,
  }),
};
</script>
<template>
  <v-card width="300" class="ma-4">
    <v-img
      height="200"
      src="@/assets/projects/about-display.jpg"
      cover
      class="text-white"
    >
      <v-toolbar color="rgba(0, 0, 0, 0)" theme="dark">
        <v-toolbar-title class="text-h6"> Visualization </v-toolbar-title>
      </v-toolbar>
    </v-img>

    <v-card-subtitle class="pt-4">
      #vuejs, #vuetify, #chartjs, #dotnetcore, #webapi
    </v-card-subtitle>

    <v-card-text>
      <p>
        The visualization of the historical data is performed within this
        application, as a VueJS component utilizing the vue-chartjs and axios
        libraries.
      </p>
      <p class="pt-2">
        The website is run in a custom built nginx container that allows me to
        host the site securely using certificates from the letsencrypt CA.
      </p>
      <p class="pt-2">
        The data is fetched from a .NET Web API which is run as another docker
        container. This container fetches the data from the PostgreSQL container
        using simple SQL queries.
      </p>
    </v-card-text>
  </v-card>
</template>
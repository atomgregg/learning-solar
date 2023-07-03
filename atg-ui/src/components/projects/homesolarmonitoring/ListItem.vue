<template>
  <v-card width="300" class="ma-4">
    <v-img
      height="200"
      src="@/assets/projects/homesolarmonitoring.jpg"
      cover
      class="text-white"
    >
      <v-toolbar color="rgba(0, 0, 0, 0)" theme="dark">
        <v-toolbar-title class="text-h6">
          Home Solar Monitoring
        </v-toolbar-title>
      </v-toolbar>
    </v-img>

    <v-card-subtitle class="pt-4">
      #dotnet, #docker, #vuejs, #postgresql, #openssl
    </v-card-subtitle>

    <v-card-text>
      <p>
        Solar power generation collection, storage and visualization using a
        Raspberry Pi.
      </p>
    </v-card-text>

    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn to="/projects/homesolarmonitoring">View</v-btn>
    </v-card-actions>
  </v-card>
</template>

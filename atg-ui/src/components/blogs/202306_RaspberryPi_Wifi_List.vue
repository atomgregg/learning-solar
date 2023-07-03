<template>
  <v-card width="300" class="ma-4">
    <v-img
      height="200"
      src="@/assets/blogs/raspberrypi-docker-setup.png"
      cover
      class="text-white"
    >
      <v-toolbar color="rgba(0, 0, 0, 0)" theme="dark">
        <v-toolbar-title class="text-h6"> Raspberry Pi Setup </v-toolbar-title>
      </v-toolbar>
    </v-img>

    <v-card-subtitle class="pt-4">
      #raspberrypi4, #ssh, #docker, #wifi-printing
    </v-card-subtitle>

    <v-card-text>
      <p>
        This article describes the initial experiences and setup of my new
        Raspberry Pi with SSH, Docker and a WiFi printer.
      </p>
    </v-card-text>

    <v-card-actions>
      <v-spacer></v-spacer>
      <v-btn to="/blogs/comingsoon">View</v-btn>
    </v-card-actions>
  </v-card>
</template>
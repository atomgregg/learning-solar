<template>
  <v-card width="300" class="ma-4">
    <v-img
      height="200"
      src="@/assets/projects/about-data-collection.jpg"
      cover
      class="text-white"
    >
      <v-toolbar color="rgba(0, 0, 0, 0)" theme="dark">
        <v-toolbar-title class="text-h6"> Data Collection </v-toolbar-title>
      </v-toolbar>
    </v-img>

    <v-card-subtitle class="pt-4">
      #dotnetcore, #solarpower, #ioc, #runners
    </v-card-subtitle>

    <v-card-text>
      <p>
        A .NET console application that connects to my solar power inverter,
        scrapes data from the web interface (there is no API on this older
        model), and stores the data in a PostgreSQL database.
      </p>
      <p class="pt-2">
        Collection and storage are written as separate libraries allowing me to
        add more source or sink types in the future.
      </p>
      <p class="pt-2">
        The runtime is configured via arguments, whereby the runner is then able
        to request the needed collection and store types from an IOC container
        and execute a highly dynamic sequence of data movement.
      </p>
    </v-card-text>
  </v-card>
</template>
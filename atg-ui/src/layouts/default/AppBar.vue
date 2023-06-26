<template>
  <v-app-bar color="cyan-darken-2" image="@/assets/header-background.jpg">
    <template v-slot:image>
      <v-img
        gradient="to top right, rgba(19,84,122,.8), rgba(128,208,199,.8)"
      ></v-img>
    </template>

    <template v-slot:prepend>
      <v-img src="/favicon-32x32.png" />
    </template>

    <v-app-bar-title>Software Innovation in Bavaria</v-app-bar-title>

    <v-btn to="/" exact>Home</v-btn>
    <v-btn to="/projects">Projects</v-btn>
    <v-btn to="/blogs">Blog</v-btn>

    <v-spacer></v-spacer>

    <v-btn icon href="mailto:atomgregg@outlook.com" target="_blank">
      <v-icon>mdi-email</v-icon>
    </v-btn>

    <v-btn icon href="https://github.com/atomgregg" target="_blank">
      <v-icon>mdi-github</v-icon>
    </v-btn>

    <v-btn icon href="https://www.linkedin.com/in/atomgregg/" target="_blank">
      <v-icon>mdi-linkedin</v-icon>
    </v-btn>

    <v-btn icon href="https://hub.docker.com/u/atomgregg" target="_blank">
      <v-icon>mdi-docker</v-icon>
    </v-btn>

    <v-btn
      icon
      href="https://www.credly.com/users/aaron-gregg.d0145bdc/badges"
      target="_blank"
    >
      <v-icon>mdi-certificate</v-icon>
    </v-btn>
  </v-app-bar>
</template>

<script setup>
//
</script>
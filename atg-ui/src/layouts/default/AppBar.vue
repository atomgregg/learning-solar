<template>
  <v-app-bar color="cyan-darken-2" image="@/assets/header-background.jpg">
    <template v-slot:image>
      <v-img
        gradient="to top right, rgba(19,84,122,.8), rgba(128,208,199,.8)"
      ></v-img>
    </template>

    <template v-slot:prepend>
      <v-img
        src="/favicon-32x32.png"
        style="cursor: pointer"
        @click="$router.push('/')"
      />
    </template>

    <v-app-bar-title
      style="cursor: pointer"
      @click="$router.push('/')"
      v-if="!mobile"
      >Software Innovation in Bavaria</v-app-bar-title
    >

    <v-spacer v-if="mobile"></v-spacer>

    <v-btn to="/" exact>Home</v-btn>
    <v-btn to="/projects">Projects</v-btn>
    <v-btn to="/blogs">Blog</v-btn>

    <v-spacer></v-spacer>

    <v-btn icon @click="drawer = true" v-if="mobile">
      <v-icon>mdi-dots-vertical</v-icon>
    </v-btn>

    <v-btn
      icon
      href="mailto:atomgregg@outlook.com"
      target="_blank"
      v-if="!mobile"
    >
      <v-icon>mdi-email</v-icon>
    </v-btn>

    <v-btn
      icon
      href="https://github.com/atomgregg"
      target="_blank"
      v-if="!mobile"
    >
      <v-icon>mdi-github</v-icon>
    </v-btn>

    <v-btn
      icon
      href="https://www.linkedin.com/in/atomgregg/"
      target="_blank"
      v-if="!mobile"
    >
      <v-icon>mdi-linkedin</v-icon>
    </v-btn>

    <v-btn
      icon
      href="https://hub.docker.com/u/atomgregg"
      target="_blank"
      v-if="!mobile"
    >
      <v-icon>mdi-docker</v-icon>
    </v-btn>

    <v-btn
      icon
      href="https://www.credly.com/users/aaron-gregg.d0145bdc/badges"
      target="_blank"
      v-if="!mobile"
    >
      <v-icon>mdi-certificate</v-icon>
    </v-btn>
  </v-app-bar>
  <v-navigation-drawer v-model="drawer" absolute temporary>
    <v-list density="compact">
      <v-list-item
        v-for="item in contactItems"
        :key="item.href"
        :href="item.href"
        target="_blank"
      >
        <template v-slot:prepend>
          <v-icon :icon="item.icon"></v-icon>
        </template>
        <v-list-item-title v-text="item.text"></v-list-item-title>
      </v-list-item>
    </v-list>
  </v-navigation-drawer>
</template>

<script setup>
import { useDisplay } from "vuetify";
const { mobile } = useDisplay();
</script>

<script>
const contactItems = [
  { href: "mailto:atomgregg@outlook.com", icon: "mdi-email", text: "Email" },
  {
    href: "https://github.com/atomgregg",
    icon: "mdi-github",
    text: "GitHub",
  },
  {
    href: "https://www.linkedin.com/in/atomgregg/",
    icon: "mdi-linkedin",
    text: "LinkedIn",
  },
  {
    href: "https://hub.docker.com/u/atomgregg",
    icon: "mdi-docker",
    text: "Docker",
  },
  {
    href: "https://www.credly.com/users/aaron-gregg.d0145bdc/badges",
    icon: "mdi-certificate",
    text: "Certifications",
  },
];

export default {
  data() {
    return {
      drawer: false,
    };
  },
};
</script>
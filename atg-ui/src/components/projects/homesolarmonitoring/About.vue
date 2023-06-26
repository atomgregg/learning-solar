<template>
  <v-sheet class="pa-2 ma-2">
        <section id="about-the-project">
            <section id="background">
                <h4 class="v-heading mb-2 text-h6">Background</h4>

                <p>
                This is a learning and experimentation project, whose purpose is
                self-education and fun. I have focused on:
                <ul class="pl-4">
                    <li class="pt-2">re-learning .NET, as this formed a very large part of my professional career and I find it a wonderful language to work with</li>
                    <li class="pt-2">learning about developing and running containerized applications, initially with docker & docker compose on a Raspberry Pi</li>
                    <li class="pt-2">learning about developing modern frontend web applications, starting with the popular VueJS framework and Vuetify library</li>
                </ul> 
                </p>
            </section>
            <section id="components" class="mt-4">
                <h4 class="v-heading mb-2 text-h6">Components</h4>

                <p>
                The project components are all deployed to a Raspberry Pi Model 4, and run as Docker containers, and joined to a docker network. The following components are run as docker containers, and together form the basis of the solution.
                </p>

                <v-responsive>
                    <v-row no-gutters justify="center" class="mb-6">
                        <v-col cols="4">
                            <AboutDataCollection></AboutDataCollection>
                        </v-col>
                        <v-col cols="4">
                            <AboutStorage></AboutStorage>
                        </v-col>
                        <v-col cols="4">
                            <AboutDisplay></AboutDisplay>
                        </v-col>
                    </v-row>
                </v-responsive>
            </section>
        </section>
    </v-sheet>
</template>

<script setup>
import AboutDataCollection from "@/components/projects/homesolarmonitoring/About.DataCollection.vue";
import AboutStorage from "@/components/projects/homesolarmonitoring/About.Storage.vue";
import AboutDisplay from "@/components/projects/homesolarmonitoring/About.Display.vue";
</script>
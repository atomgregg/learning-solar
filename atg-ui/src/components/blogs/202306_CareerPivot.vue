<template>
  <v-sheet class="pa-2 ma-2">
    <section id="article-header">
      <h4 class="v-heading mb-2 text-h3">Career Pivot</h4>
      <p class="font-weight-thin">June 30, 2023</p>
    </section>

    <section id="article-tldr-title" class="pt-6">
        <h4 class="v-heading mb-2 text-h6">TL;DR</h4>
      </section>

    <section id="article-tldr">
      <p>
        <ul class="ml-4">
            <li class="pt-2">After 6 years in leadership roles, I am redirecting my focus to dive deep on the latest technologies and development paradigms</li>
            <li class="pt-2">My primary intention is to return to my roots as a technologist, and close the gap that widened as I focused on doing my best as a leader</li>
            <li class="pt-2">In the mid-term I will decide whether to remain on this pathway as a hands-on technologist, or if I will return to a leadership role with renewed skills &amp; awareness of modern software product development challenges</li>
        </ul>
      </p>
    </section>

    <section id="article-background-title" class="pt-6">
      <h4 class="v-heading mb-2 text-h6">Background</h4>
    </section>

    <section id="article-background" v-if="mobile">
      <v-row>
        <v-col cols="12">
          <v-img
            src="@/assets/blogs/career-pivot/part-background.jpg"
            cover
            class="ma-2"
            height="200px"
          />
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12">
          <p class="pb-4" v-for="text in backgroundText" :key="text">{{text}}</p>
        </v-col>
      </v-row>
    </section>

    <section id="article-background" v-else>
      <v-row>
        <v-col cols="6">
          <p class="pb-4" v-for="text in backgroundText" :key="text">{{text}}</p>
        </v-col>
        <v-col cols="6">
          <v-img
            src="@/assets/blogs/career-pivot/part-background.jpg"
            cover
            class="ma-2"
          />
        </v-col>
      </v-row>
    </section>

    <section id="article-pivot-title" class="pt-6">
      <h4 class="v-heading mb-2 text-h6">The Pivot</h4>
    </section>

    <section id="article-pivot" v-if="mobile">
      <v-row>
        <v-col cols="12">
          <v-img
            src="@/assets/blogs/career-pivot/part-pivot.jpg"
            cover
            class="ma-2"
          />
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12">
          <p class="pb-4" v-for="text in pivotText" :key="text">{{text}}</p>
        </v-col>
      </v-row>
    </section>

    <section id="article-pivot" v-else>
      <v-row>
        <v-col cols="6">
          <v-img
            src="@/assets/blogs/career-pivot/part-pivot.jpg"
            cover
            class="ma-2"
          />
        </v-col>
        <v-col cols="6">
          <p class="pb-4" v-for="text in pivotText" :key="text">{{text}}</p>
        </v-col>
      </v-row>
    </section>

    <section id="article-whats-next-title" class="pt-6">
      <h4 class="v-heading mb-2 text-h6">What's Next</h4>
    </section>

    <section id="article-whats-next" v-if="mobile">
      <v-row>
        <v-col cols="12">
          <v-img
            src="@/assets/blogs/career-pivot/whats-next.jpg"
            cover
            class="ma-2"
          />
        </v-col>
      </v-row>
      <v-row>
        <v-col cols="12">
          <p class="pb-4" v-for="text in nextText" :key="text">{{text}}</p>
        </v-col>
      </v-row>
    </section>

    <section id="article-whats-next" v-else>
      <v-row>
        <v-col cols="6">
          <p class="pb-4" v-for="text in nextText" :key="text">{{text}}</p>
        </v-col>
        <v-col cols="6">
          <v-img
            src="@/assets/blogs/career-pivot/whats-next.jpg"
            cover
            class="ma-2"
          />
        </v-col>
      </v-row>
    </section>
    
  </v-sheet>
</template>

<script setup>
import { useDisplay } from "vuetify";
const { mobile } = useDisplay();

const backgroundText = [
  "The background to this story begins at the start of 2022 when I received a new boss who would bring plenty of experience the company could benefit from as well as me personally.",
  "Unfortunately in my humble 6 years in leadership roles, I had developed a strong sense for how I want to lead, and this clashed with my new boss' approach.",
  "We worked closely for more than a year, trying to use both of our styles and approaches to complement one another, but we realised this wasn't good for either of us, and definitely not good for our company and teams. So we started talking about options for me.",
  "After many long discussions, my boss decided that the only option was that I leave the company",
  "Looking back, I am proud of the many achievements we made together. Paessler product development is now in a strong position, with strong local ownership &amp; trust in another for products and projects, and much clearer visibility on the biggest challenges that the entire dept &amp; company must overcome together.",
  "My time with Paessler has been amazing, I have been priviledged to work with many wonderful &amp; talented people, and created new long friendships.",
];

const pivotText = [
  "Faced with the realization I need to leave a place where I've invested so much of me, I was free to think what to do next.",
  "In the last 6+ years as CTO at Symanto and then as VP Engineering at Paessler, my job was to create the most effective, efficient, and fulfilling environment possible.",
  "In my conversations with my teams, I was always fascinated and excited about the amazing things they were building.",
  "Containerization was the norm, VueJS &amp; React and their declarative wonder tempted me to delve back into web development, Golang &amp; Rust had grown from their nascent beginnings and were really showing their potential, and .NET, my longest association with professional programming, was growing strongly beyond Windows-only into a full eco-system waiting to be re-explored.",
  "Perhaps it was time to return to my roots and enjoy some of that exciting software development that my team members were enjoying every day.",
];

const nextText = [
  "Having a young family including an 8 yr old girl who loves her ballet lessons, and a 7 yr old boy full of love and excitement, I realised that the time I have with them today, I will never get back.. My priority above all is to be here for them.",
  "For my career pivot, this means that for the short term I will not jump straight back into the next full-time role and lose myself and this precious time into my endeavours.",
  "I will look for some part-time development projects that catch my interest, where I can dive into my passion for technology and re-develop a keen understanding for the big paradigms happening in development (e.g. prompt engineering with LLM's), but with a keen eye to maintain a healthy balance to the most important people in my life.",
  'So far I\'ve started some home projects to re-acquaint myself with developing software, and got myself re-accredited in Microsoft Azure technologies. For the future, "watch this space", as I intend to post on my experiences and challenges here as I have time to do so.',
];
</script>
<template>
  <section id="aboutme">
    <section id="background">
      <h4 class="v-heading mb-2 text-h6">Background</h4>

      <p>
        My name is Aaron Gregg, an experienced software developer, architect,
        team player, generalist, leader/coach, an Australian living in Bavaria,
        Germany since 2010.
      </p>
      <p>
        I live in the Oberpfalz with my wife, 2 children and various chickens.
        Before moving to this beautiful place on earth, I grew up in Darwin, NT,
        Australia.
      </p>
      <p>
        A big part of my life before moving was hockey, specifically field
        hockey and the Banks Hockey Club. Through hockey, I gained valuable
        experiences in coaching, teaching, giving and leadership that became
        part of who I am, and played a big role in my professional career in
        software and business.
      </p>
    </section>
    <section id="motivation">
      <h4 class="v-heading mb-2 text-h6">Motivation</h4>

      <p>
        Whilst the last years in my career have been immensely rewarding as a
        servant leader, strategist and innovator, I have chosen to re-steer my
        career and invest my time in creating software.
      </p>
      <p>
        So much is happening in software right now, re-learning my craft as an
        engineer and creator is not only immensely rewarding and exciting, it's
        the perfect timing.
      </p>
    </section>
    <section id="experience">
      <h4 class="v-heading mb-2 text-h6">Experience</h4>

      <v-list lines="two">
        <v-list-item
          title="VP Software Engineering @ Paessler AG"
          subtitle="Jan 2020 - Apr 2023"
        >
          <template v-slot:prepend>
            <v-avatar rounded="0">
              <v-img
                alt="Paessler AG Logo"
                src="@/assets/experience/paessler_ag.jpg"
              ></v-img>
            </v-avatar>
          </template>

          <template v-slot:append>
            <v-tooltip bottom :disabled="valid">
              <template v-slot:activator="{ props }">
                <div v-bind="props" class="d-inline-block">
                  <v-btn
                    color="grey-lighten-1"
                    icon="mdi-information"
                    variant="text"
                  ></v-btn>
                </div>
              </template>
              <span
                >Experiences: servant leadership, innovation, strategy, systems
                thinking</span
              >
            </v-tooltip>
          </template>
        </v-list-item>

        <v-list-item
          title="Architect then CTO @ Symanto GmbH"
          subtitle="Jan 2016 - Sept 2019"
        >
          <template v-slot:prepend>
            <v-avatar rounded="0">
              <v-img
                alt="Symanto GmbH Logo"
                src="@/assets/experience/symanto_gmbh.png"
              ></v-img>
            </v-avatar>
          </template>

          <template v-slot:append>
            <v-tooltip bottom :disabled="valid">
              <template v-slot:activator="{ props }">
                <div v-bind="props" class="d-inline-block">
                  <v-btn
                    color="grey-lighten-1"
                    icon="mdi-information"
                    variant="text"
                  ></v-btn>
                </div>
              </template>
              <span
                >Experiences: architecture, cloud native, ai/ml, nlp, data
                processing, leadership, innovation, startup</span
              >
            </v-tooltip>
          </template>
        </v-list-item>

        <v-list-item
          title="Senior Consultant @ Avande GmbH"
          subtitle="Oct 2014 - Dec 2015"
        >
          <template v-slot:prepend>
            <v-avatar rounded="0">
              <v-img
                alt="Avanade GmbH Logo"
                src="@/assets/experience/avanade_gmbh.png"
              ></v-img>
            </v-avatar>
          </template>

          <template v-slot:append>
            <v-tooltip bottom :disabled="valid">
              <template v-slot:activator="{ props }">
                <div v-bind="props" class="d-inline-block">
                  <v-btn
                    color="grey-lighten-1"
                    icon="mdi-information"
                    variant="text"
                  ></v-btn>
                </div>
              </template>
              <span
                >Experiences: consulting, team-work, innovation,
                architecture</span
              >
            </v-tooltip>
          </template>
        </v-list-item>

        <v-list-item
          title="Engineer then Technical Lead @ Mueller Verlag"
          subtitle="Jun 2009 - Sept 2014"
        >
          <template v-slot:prepend>
            <v-avatar rounded="0">
              <v-img
                alt="Mueller Verlag GmbH Logo"
                src="@/assets/experience/muellermedien_gmbh.jpg"
              ></v-img>
            </v-avatar>
          </template>

          <template v-slot:append>
            <v-tooltip bottom :disabled="valid">
              <template v-slot:activator="{ props }">
                <div v-bind="props" class="d-inline-block">
                  <v-btn
                    color="grey-lighten-1"
                    icon="mdi-information"
                    variant="text"
                  ></v-btn>
                </div>
              </template>
              <span
                >Experiences: architecture, data processing, raw performance,
                team-work</span
              >
            </v-tooltip>
          </template>
        </v-list-item>

        <v-list-item
          title="Engineer then Technical Lead @ Fujitsu Australia"
          subtitle="Jan 2005 - Jun 2009"
        >
          <template v-slot:prepend>
            <v-avatar rounded="0">
              <v-img
                alt="Fujitsu Logo"
                src="@/assets/experience/fujitsu.jpg"
              ></v-img>
            </v-avatar>
          </template>

          <template v-slot:append>
            <v-tooltip bottom :disabled="valid">
              <template v-slot:activator="{ props }">
                <div v-bind="props" class="d-inline-block">
                  <v-btn
                    color="grey-lighten-1"
                    icon="mdi-information"
                    variant="text"
                  ></v-btn>
                </div>
              </template>
              <span
                >Experiences: consulting, mainframe, web solutions,
                team-work</span
              >
            </v-tooltip>
          </template>
        </v-list-item>
      </v-list>
    </section>
  </section>
</template>

<script setup>
//
</script>

<style>
section p {
  margin-bottom: 1rem;
}
</style>

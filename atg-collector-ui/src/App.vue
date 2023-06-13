<head>
  <!-- Other head elements -->
  <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto:400,700&display=swap">
</head>

<template>
  <div id="app">
    <header class="header-styles">
      <div class="logo">
        <!-- Insert your logo here -->
      </div>
        <nav>
          <ul id="main-nav" class="desktop:flex w-full desktop:py-4 desktop:space-x-3">
            <li data-main-menu="closed" class="relative w-auto tablet:px-8 phone:px-8">
              <a href="/solutions" class="relative block desktop:p-2 py-3 smalldesktop:px-1 h-full uppercase font-medium text-base desktop:hover:text-cyan">Products</a>
            </li>

            <li data-main-menu="closed" class="relative w-auto tablet:px-8 phone:px-8">
              <a href="/solutions" class="relative block desktop:p-2 py-3 smalldesktop:px-1 h-full uppercase font-medium text-base desktop:hover:text-cyan">Solutions</a>
            </li>

            <li data-main-menu="closed" class="relative w-auto tablet:px-8 phone:px-8">
              <a href="/solutions" class="relative block desktop:p-2 py-3 smalldesktop:px-1 h-full uppercase font-medium text-base desktop:hover:text-cyan">Support</a>
            </li>

            <li data-main-menu="closed" class="relative w-auto tablet:px-8 phone:px-8">
              <a href="/solutions" class="relative block desktop:p-2 py-3 smalldesktop:px-1 h-full uppercase font-medium text-base desktop:hover:text-cyan">Company</a>
            </li>
          </ul>
        </nav>
      <nav class="navigation">
        <ul>
          <li><a href="#intro">Intro</a></li>
          <li><a href="#kostal">Kostal Inverter</a></li>
          <li><a href="#contact">Contact</a></li>
        </ul>
      </nav>
    </header>
    <div class="content">
      <main class="content">
          <!-- Place your chart component or other content here -->
          <BasicChart></BasicChart>
        </main>
    </div>
  </div>
</template>

<style>
html, body {
  font-family: 'Roboto', sans-serif;
  /* Other title bar styles */
}

.header {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  background-color: #007bff;
  padding: 10px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  z-index: 999;
}

@media (min-width: 1000px)
.header-styles {
    position: -webkit-sticky;
    position: sticky;
}

.header-styles {
    --tw-text-opacity: 1;
    color: rgb(5 15 52/var(--tw-text-opacity));
    font-size: 1rem;
    line-height: 1.25rem;
    text-align: left;
    top: 0;
    z-index: 10;
}

.logo {
  font-family: 'Roboto', sans-serif;
  font-size: 24px;
  color: #fff;
}

.navigation ul {
  list-style: none;
  display: flex;
}

.navigation li {
  margin-right: 10px;
}

.navigation a {
  font-family: 'Roboto', sans-serif;
  font-size: 16px;
  color: #fff;
  text-decoration: none;
}

.content {
  padding-top: 80px; /* Add a top padding to avoid content being hidden behind the fixed header */
}

.container {
  display: flex;
}

.navigation-panel {
  background-color: #f0f0f0;
  padding: 20px;
  width: 200px;
}

.navigation-panel ul {
  list-style-type: none;
  padding: 0;
}

.navigation-panel li {
  margin-bottom: 10px;
}

.content {
  flex-grow: 1;
  padding: 20px;
}
</style>

<script>
import BasicChart from './components/BasicChart.vue';

export default {
  name: 'App',
  components: {
    BasicChart,
  },
};

</script>
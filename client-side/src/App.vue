<template>
  <div>
    <Navbar />
    <RouterView></RouterView>
  </div>
</template>

<script>
import Navbar from '@/components/Navbar.vue';
export default {
  components: {
    Navbar
  }
}
</script>

<style>
body {
  background: url('/img/wallpaper-.jpg')no-repeat;
  background-size: cover;
  background-position: center;
  min-height: 100vh;
}

::-webkit-scrollbar {
  width: 10px;
}

::-webkit-scrollbar-track {
  background: white;
  box-shadow: inset 0 0 5px grey;
}

::-webkit-scrollbar-thumb {
  background: grey;
}

::-webkit-scrollbar-thumb:hover {
  background: #5A5A5A;
}</style>

<template>
  <div>
      <h2 class="pageName">Blogs</h2>
      <BlogList />
  </div>
</template>

<script>
import BlogList from '@/components/BlogList.vue';
export default {
components: {
  BlogList
}
}
</script>

<style>
body {
margin: none;
}
.pageName {
text-align: center;
color: white;
}
</style>

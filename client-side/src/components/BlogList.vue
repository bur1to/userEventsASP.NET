<template>
    <div class="blog" v-for="blog in blogs" :key="blog.id">
        <div class="title"><strong>Title: </strong>{{ blog.title }}</div>
        <div class="themes"><strong>Themes: </strong>{{ blog.themes }}</div>
        <div class="content"><strong>Content: </strong>{{ blog.content }}</div>
        <div class="date"><strong>Date: </strong>{{ new Date(blog.postDate).toLocaleDateString('uk-UA') }}</div>
        <div class="read">
            <button class="link" @click="getBlog(blog.id)">Read</button>
        </div>
    </div>
    <div class="page__wrapper">
        <div v-for="pageNumber in totalPages" :key="pageNumber" class="page" :class="{
            'current-page': page === pageNumber
        }" @click="changePage(pageNumber)">{{ pageNumber }}</div>
    </div>
</template>

<script>
import router from '@/router';
import axios from 'axios';
export default {
    data() {
        return {
            blogs: [],
            page: 1,
            limit: 5,
            totalPages: 0
        }
    },
    methods: {
        changePage(pageNumber) {
            this.page = pageNumber;
            this.getBlogs({ page: pageNumber - 1, limit: this.limit });
        },
        getBlogs(params) {
            try {
                axios.get('https://localhost:7219/Blog', { params })
                  .then((res) => {
                    this.blogs = res.data.item1;
                    this.totalPages = Math.ceil(res.data.item2 / this.limit);
                  })
                  .catch((err) => console.log(err));
                
            } catch (err) {
                console.log(err);
            }
        },
        getBlog(id) {
            try {
                localStorage.setItem('blogId', id);
                router.push('/blog');
            } catch (err) {
                console.log(err);
            }
        }
    },
    mounted() {
        this.getBlogs();
    }
}
</script>

<style>
.blog {
    border-radius: 15px;
    margin-top: 15px;
    margin-left: 225px;
    width: 900px;
    padding: 15px;
    padding-top: 15px;
    background: rgba(0, 0, 0, 0.3);
    color: white;
    border: 2px solid white;
}
.title,
.themes,
.content {
    padding-bottom: 15px;
}
.title,
.themes,
.content,
.date {
    font-size: 20px;
}
.read {
    display: flex;
    justify-content: flex-end;
}
.link {
    border-radius: 15px;
    padding: 5px 15px 3px 15px;
    border: 2px solid white;
    color: white;
    background: none;
    font-size: 20px;
}
.link:visited {
    color: white;
}
.link:hover {
    background: white;
    color: black;
}
</style>
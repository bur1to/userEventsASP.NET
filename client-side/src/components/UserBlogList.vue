<template>
    <h3 style="text-align: center;">Your blogs:</h3>
    <div class="blog1" v-for="blog in blogs" :key="blog.id">
        <div class="title"><strong>Title: </strong>{{ blog.title }}</div>
        <div class="themes"><strong>Themes: </strong>{{ blog.themes }}</div>
        <div class="content"><strong>Content: </strong>{{ blog.content }}</div>
        <div class="date"><strong>Date: </strong>{{ new Date(blog.postDate).toLocaleDateString('uk-UA') }}</div>
        <div class="read">
            <button class="btn15" @click="getBlog(blog.id)">Read</button>
            <button class="btn12" @click="deleteBlog(blog.id)">Delete</button>
            <button class="btn13" @click="editBlog(blog.id)" :blog="blogs">Edit</button>
        </div>
    </div>
    <div class="page__wrapper">
        <div v-for="pageNumber in totalPages" :key="pageNumber" class="page" :class="{
            'current-page': page === pageNumber
        }" @click="changePage(pageNumber)">{{ pageNumber }}</div>
    </div>
</template>

<script>
import axios from 'axios';
import router from '@/router';
export default {
    data() {
        return {
            blogs: [],
            page: 1,
            limit: 5,
            sort: 'title',
            sortBy: 'asc',
            totalPages: 0
        }
    },
    methods: {
        changePage(pageNumber) {
            this.page = pageNumber;
            this.getUserBlogs({ page: pageNumber - 1 });
        },
        getUserBlogs(params) {
            try {
                axios.get(`https://localhost:7219/Blog/${localStorage.getItem('id')}/userBlogs`, { params })
                  .then((res) => {
                    console.log(res.data)
                    this.blogs = res.data.item1;
                    this.totalPages = Math.ceil(res.data.item2 / this.limit);
                })
                  .catch((err) => console.log(err));
            } catch (err) {
                console.log(err);
            }
        },
        deleteBlog(id) {
            try {
                axios.delete(`https://localhost:7219/Blog/${id}`);
            } catch (err) {
                console.log(err);
            }
        },
        async getBlog(id) {
            try {
                localStorage.setItem('blogId', id);
                router.push('/blog');
            } catch (err) {
                console.log(err);
            }
        },
        editBlog(id) {
            localStorage.setItem('blogId', id);
            router.push('/edit_blog');
        }
    },
    mounted() {
        this.getUserBlogs();
    }
}
</script>

<style>
.blog1 {
    border-radius: 15px;
    margin-top: 10px;
    margin-left: 155px;
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
.btn15 {
    border-radius: 15px;
    padding: 3px 11px 3px 11px;
    border: 2px solid white;
    color: white;
    background: none;
    font-size: 20px;
}
.btn15:hover {
    background: white;
    color: black;
}
.btn12,
.btn13 {
    margin-left: 15px;
    border: 2px solid white;
    border-radius: 15px;
    padding: 3px 11px 3px 11px;
    font-size: 20px;
    color: white;
    background: none;
}
.edit {
    color: white;
    font-size: 20px;
}
.edit:hover {
    color: black;
}
.edit:visited {
    color: white;
}
.btn12:hover,
.btn13:hover {
    background: white;
    color: black;
}
</style>
<template>
    <div class="blogForm">
        <div class="createForm">
            <form @submit.prevent>
                <h3 class="h4">Create blog</h3>
                <label>
                    Title:
                </label>
                <input class="input" v-model="blog.title" type="text" placeholder="Blog title"><br />
                <label>
                    Themes:
                </label>
                <input class="input" v-model="blog.themes" type="text" placeholder="Themes of your blog"><br />
                <label>
                    Content of your blog:
                </label>
                <textarea class="textarea" v-model="blog.content" placeholder="Blog content"></textarea><br />
                <label>
                    Post date:
                </label>
                <input class="input" v-model="blog.postDate" type="date">
                <div class="btn_block3">
                    <button class="btn5" @click="updateBlog">Edit</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
import router from '@/router';
import axios from 'axios';
export default {
    data() {
        return {
            blog: []
        }
    },
    methods: {
        updateBlog() {
            try {
                axios.put(`https://localhost:7219/Blog/${localStorage.getItem('blogId')}`, this.blog)
                    .then((res) => {
                        console.log(res);
                        router.push('/');
                    })
                    .catch((err) => console.log(err));
                this.$emit('edit', this.blog);
            } catch (err) {
                console.log(err);
            }
        },
        getBlog() {
            const { data } = axios.get(`https://localhost:7219/Blog/${localStorage.getItem('blogId')}`);
            this.blog = data;
        }
    },
    mounted() {
        this.getBlog();
    }
}
</script>

<style>
.blogForm {
    display: flex;
    justify-content: center;
    color: white;
}
.createForm {
    display: flex;
    justify-content: center;
    background: rgba(0, 0, 0, 0.4);
    width: 900px;
    margin-top: 5px;
    border-radius: 20px;
    border: 2px solid white;
}
.input {
    width: 300px;
    border: 2px solid white;
    padding: 10px 15px;
    margin-top: 15px;
}
.btn_block3 {
    margin-top: 20px;
    margin-bottom: 20px;
}
.btn5 {
    font-size: 20px;
    padding: 3px 15px 3px 15px;
    border-radius: 15px;
    border: 2px solid white;
    background: none;
    color: white;
}
.btn5:hover {
    background: white;
    color: black;
}
.textarea {
    width: 600px;
    height: 200px;
    border: 2px solid teal;
    padding: 10px 15px;
    margin-top: 15px;
    border-radius: 5px;
}
</style>
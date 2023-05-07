<template>
    <div class="blog2">
        <div class="title2"><strong>{{ blog.title }}</strong></div>
        <div><strong>Themes: </strong>{{ blog.themes }}</div>
        <div class="content2">{{ blog.content }}</div>
        <div><strong>Date: </strong>{{ new Date(blog.postDate).toLocaleDateString('uk-UA') }}</div>
        <div><strong>Author: </strong>{{ `${user.firstName} ${user.lastName}` }}</div>
    </div>
    <div class="comment">
        <button class="com" @click="showDialog">Add comment</button>
    </div>
    <my-dialog v-model:show="dialogVisible">
        <CommentForm @create="createComment" />
    </my-dialog>
    <div class="comments">
        <CommentList />
    </div>
</template>

<script>
import axios from 'axios';
import CommentForm from '@/components/CommentForm.vue';
import CommentList from '@/components/CommentList.vue';
export default {
    components: {
        CommentForm,
        CommentList
    },
    data() {
        return {
            blog: [],
            user: [],
            comments: [],
            dialogVisible: false
        }
    },
    methods: {
        getBlog() {
            try {
                axios.get(`https://localhost:7219/Blog/${localStorage.getItem('blogId')}`)
                  .then((res) => {
                    this.blog = res.data;
                    axios.get(`https://localhost:7219/User/${res.data.userId}`)
                      .then((res) => this.user = res.data)
                      .catch((err) => console.log(err));
                  })
                  .catch((err) => console.log(err));
            } catch (err) {
                console.log(err);
            }
        },
        showDialog() {
            this.dialogVisible = true;
        },
        createComment(comment) {
            this.comments.push(comment);
            this.dialogVisible = false;
        }
    }, 
    mounted() {
        this.getBlog();
    }
}
</script>

<style>
.title2 {
    text-align: center;
    padding-bottom: 10px;
}
.blog2 {
    margin-top: 20px;
    font-size: 22px;
    padding: 20px;
    background: rgba(0, 0, 0, 0.3);
    color: white;
    border-radius: 20px;
    border: 2px solid white;
}
.comment {
    margin-top: 15px;
    display: flex;
    justify-content: flex-end;
}
.com {
    background: none;
    color: white;
    border: 2px solid white;
    border-radius: 15px;
    padding: 3px 11px 3px 11px;
    font-size: 20px;
    margin-bottom: 15px;
}
.com:hover {
    background: white;
    color: black;
}
.content2 {
    padding-top: 20px;
    padding-bottom: 15px;
}
.comments {
    background: rgba(0, 0, 0, 0.3);
    border-radius: 20px;
    border: 2px solid white;
}
.date2 {
    text-align: right;
}
</style>
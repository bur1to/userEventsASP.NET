<template>
    <div style="color: white; font-size: 22px; padding: 15px;"> {{ comments.length }} Comments</div>
    <div class="commentList" v-for="comment in comments" :key="comment.id">
        <div style="margin-bottom: 5px;">{{ comment.author }}</div>
        <div>{{ comment.content }}</div>
        <div>
            <button class="rep" @click="showDialog">Reply</button>
            <button class="edt" v-if="btnVisible === true" @click="updateComment(comment.id)">Edit</button>
            <button class="del" v-if="btnVisible === true" @click="deleteComment(comment.id)">Delete</button>
        </div>
        <div>
            <my-dialog v-model:show="dialogVisible">
                <CommentForm @create="replyToComment" />
            </my-dialog>
        </div>
    </div>
</template>
  
<script>
import axios from 'axios';
import CommentForm from '@/components/CommentForm.vue';
export default {
    components: {
        CommentForm
    },
    data() {
        return {
            comments: [],
            comment: [],
            btnVisible: false,
            dialogVisible: false
        }
    },
    methods: {
        getBlogComments() {
            try {
                axios.get(`https://localhost:7219/Comment/${localStorage.getItem('blogId')}`)
                  .then((res) => this.comments = res.data)
                  .catch((err) => console.log(err));
            } catch (err) {
                console.log(err);
            }
        },
        deleteComment(id) {
            try {
                axios.delete(`https://localhost:7219/Comment/${id}`);
            } catch (err) {
                console.log(err);
            }
        },
        updateComment(id) {
            try {
                axios.put(`https://localhost:7038/Comment/${id}`);
            } catch (err) {
                console.timeLog(err);
            }
        },
        replyToComment(comment) {
            this.comment.push(comment);
            this.dialogVisible = false;
        },
        showDialog() {
            this.dialogVisible = true;
        }
    },
    mounted() {
        this.getBlogComments();
    }
}
</script>
  
<style>
.commentList {
    color: white;
    font-size: 20px;
    border-radius: 15px;
    padding: 15px;
}

.rep,
.edt,
.del {
    margin-top: 5px;
    background: none;
    border-radius: 15px;
    border: 2px solid white;
    color: white;
    padding: 3px 11px 3px 11px;
    font-size: 15px;
}

.edt,
.del {
    margin-left: 15px;
}

.rep:hover,
.edt:hover,
.del:hover {
    color: black;
    background: white;
}</style>
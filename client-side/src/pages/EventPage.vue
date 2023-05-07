<template>
    <div class="event1">
        <div class="eventTitle">{{ event.title }}</div>
        <div class="eventContent">{{ event.description }}</div>
        <div class="eventDate">
            {{
                `From ${new Date(event.startDate).toLocaleDateString('uk-UA')}
                till ${new Date(event.endDate).toLocaleDateString('uk-UA')}`
            }}
        </div>
        <div class="eventOrganizator">{{ `${user.firstName} ${user.lastName}` }}</div>
    </div>
    <div class="comment">
        <button class="com" @click="showDialog">Add comment</button>
    </div>
    <my-dialog v-model:show="dialogVisible">
        <CommentEventForm @create="createComment" />
    </my-dialog>
    <div class="comments">
        <CommentEventList />
    </div>
</template>

<script>
import CommentEventForm from '@/components/CommentEventForm.vue';
import CommentEventList from '@/components/CommentEventList.vue';
import axios from 'axios';
export default {
    components: {
        CommentEventForm,
        CommentEventList
    },
    data() {
        return {
            event: [],
            user: [],
            comments: [],
            dialogVisible: false
        }
    },
    methods: {
        getEvent() {
            axios.get(`https://localhost:7219/Event/${localStorage.getItem('eventId')}/event`)
              .then((res) => {
                this.event = res.data;
                axios.get(`https://localhost:7219/User/${res.data.userId}`)
                  .then((res) => this.user = res.data)
                  .catch((err) => console.log(err))
              })
              .catch((err) => console.log(err));
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
        this.getEvent();
    }
}
</script>

<style>
.event1 {
    margin-top: 20px;
    font-size: 22px;
    padding: 20px;
    background: rgba(0, 0, 0, 0.3);
    color: white;
    border-radius: 20px;
    border: 2px solid white;
}

.eventTitle {
    text-align: center;
    font-size: 30px;
}

.eventContent, .eventDate, .eventOrganizator {
    padding-top: 10px;
}
</style>
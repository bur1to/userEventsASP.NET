<template>
    <div class="user">
        <div>
            <h2>{{ `${user.firstName} ${user.lastName}` }}</h2>
        </div>
        <div style="font-size: 20px;"><strong>Email: </strong>{{ user.email }}</div>
        <div style="font-size: 20px;"><strong>Phone Number: </strong>{{ user.phoneNumber }}</div>
        <div class="btn_block4">
            <button class="btn6" @click="showEvent">My events</button>
            <button class="btn7" @click="showBlog">My blogs</button>
            <button class="btn14" @click="editPage" :user="user">Edit profile</button>
        </div>
        <div v-if="showEvents === true">
            <EventList :events="events" />
        </div>
        <div v-if="showEvents === false">
            <UserBlogList :blogs="blogs" />
        </div>
    </div>
</template>

<script>
import router from '@/router';
import axios from 'axios';
import EventList from '@/components/EventList.vue';
import UpdateUserForm from '@/components/UpdateUserForm.vue';
import UserBlogList from '@/components/UserBlogList.vue';
export default {
    components: {
        EventList,
        UpdateUserForm,
        UserBlogList
    },
    data() {
        return {
            user: [],
            events: [],
            blogs: [],
            showEvents: true
        }
    },
    methods: {
        getUser() {
            try {
                axios.get(`https://localhost:7219/User/${localStorage.getItem('id')}`)
                  .then((res) => this.user = res.data)
                  .catch((err) => console.log(err));
            } catch (err) {
                console.log(err);
            }
        },
        createEvent(event) {
            this.events.push(event);
        },
        createBlog(blog) {
            this.blogs.push(blog);
        },
        showBlog() {
            this.showEvents = false;
        },
        showEvent() {
            this.showEvents = true;
        },
        editPage() {
            router.push('/edit_profile');
        }
    },
    mounted() {
        this.getUser();
    }
}
</script>

<style>
.user {
    margin-top: 20px;
    padding: 15px;
    margin-left: 15px;
    margin-right: 15px;
    background: rgba(0, 0, 0, 0.5);
    border-radius: 20px;
    height: auto;
    width: auto;
    color: white;
    border: 2px solid white;
}
.btn_block4 {
    margin-top: 20px;
}
.btn6 {
    margin-right: 15px;
    font-size: 20px;
    border-radius: 15px;
    padding: 3px 12px 3px 12px;
}
.btn7 {
    font-size: 20px;
    border-radius: 15px;
    padding: 3px 12px 3px 12px;
}
.btn6,
.btn7 {
    background: none;
    color: white;
    border: 2px solid white;
}
.btn6:hover,
.btn7:hover {
    background: white;
    color: black;
}
.btn14 {
    background: none;
    margin-left: 15px;
    border: 2px solid white;
    border-radius: 13px;
    color: white;
    padding: 3px 11px 3px 11px;
    font-size: 20px;
}
.btn14:hover {
    background: white;
    color: black;
}
</style>
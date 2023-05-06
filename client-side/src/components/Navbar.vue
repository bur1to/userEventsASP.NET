<template>
    <nav v-if="isLogged === true">
        <div class="nav">
            <div class="btn_block1">
                <button class="btn" @click="logOut">Log out</button>
            </div>
            <ul class="ul">
                <li><router-link to="/" class="routerLink">Blogs</router-link></li>
                <router-link to="/events" class="routerLink">Events</router-link>
                <li><router-link to="/create_blog" class="routerLink">Add blog</router-link></li>
                <li><router-link to="/create_event" class="routerLink">Add event</router-link></li>
            </ul>
            <router-link to="/profile" class="profile">{{ `${user.firstName} ${user.lastName}` }}</router-link>
        </div>
    </nav>

    <div class="btn_block2" v-if="isLogged === false">
        <router-link to="/login"><button class="btn9">Log in</button></router-link>
        <div class="home">
            <ul class="ul">
                <li><router-link to="/" class="routerLink home">Blogs</router-link></li>
                <li><router-link to="/events" class="routerLink home2">Events</router-link></li>
            </ul>
        </div>
    </div>
</template>

<script>
import router from '@/router';
import LoginForm from '@/components/LoginForm.vue';
import UserForm from '@/components/UserForm.vue';
import axios from 'axios';
export default {
    components: {
        LoginForm,
        UserForm
    },
    data() {
        return {
            isLogged: this.checkIfIsLogged(),
            user: []
        }
    },
    methods: {
        logOut() {
            localStorage.removeItem('token');
            localStorage.removeItem('blogId');
            localStorage.removeItem('id');
            localStorage.removeItem('editId');
            router.push('/');
        },
        checkIfIsLogged() {
            let token = localStorage.getItem('token');
            if (token) {
                return true;
            } else {
                return false;
            }
        },
        getUserName() {
            try {
                axios.get(`https://localhost:7219/User/${localStorage.getItem('id')}`)
                  .then((res) => this.user = res.data)
                  .catch((err) => console.log(err));
            } catch (err) {
                console.log(err);
            }
        }
    },
    mounted() {
        this.checkIfIsLogged();
        this.getUserName();
    }
}
</script>

<style>
.nav {
    display: flex;
    justify-content: center;
    justify-content: space-between;
    padding: 5px;
    padding-top: 0px;
    text-align: center;
}

.btn_block1 {
    display: flex;
    align-self: center;
    margin-right: 10px;
}

.btn_block2 {
    display: flex;
    justify-content: flex-start;
    margin-right: 12px;
    padding-top: 10px;
    font-size: 20px;
}

.btn,
.btn9 {
    display: flex;
    background: none;
    font-size: 20px;
    color: white;
    border: 2px solid white;
    border-radius: 15px;
    padding: 5px 15px 5px 15px;
}

.btn:hover,
.btn9:hover {
    background: white;
    color: black;
}

.ul {
    display: flex;
    margin-left: 45px;
    gap: 8;
    list-style-type: none;
}

.routerLink {
    display: flex;
    padding-left: 10px;
    color: gray;
    font-size: 20px;
}

.profile {
    display: flex;
    margin-top: 17px;
    margin-right: 5px;
    font-size: 20px;
    color: gray;
}

.home {
    padding-left: 210px;
    margin-top: -9px;
}

.home2 {
    margin-top: -9px;
}

.routerLink:visited,
.profile:visited {
    color: gray;
}

.routerLink:hover,
.profile:hover {
    color: white;
}

.routerLink.active-link,
.profile.active-link {
    color: white;
}
</style>
<template>
    <title>Registration</title>
    <div class="register_block">
        <div class="registerForm">
            <form @submit.prevent class="form">
                <h3 class="h4">Registration</h3>
                <label>
                    Username: <br />
                </label>
                <input v-model="user.firstName" class="input" type="text" placeholder="First name">
                <input v-model="user.lastName" class="input" type="text" placeholder="Second name"> <br />
                <label>
                    Email: <br />
                </label>
                <input v-model="user.email" class="input" type="email" placeholder="example@example.com"> <br />
                <label>
                    Phone number: <br />
                </label>
                <input v-model="user.phoneNumber" class="input" type="text" placeholder="+(38) 111 111 1111"> <br />
                <label>
                    Password: <br />
                </label>
                <input v-model="user.password" class="input" type="password" placeholder="Your account password"> <br />
                <label>
                    Confirm password: <br />
                </label>
                <input v-model="user.confirmPassword" class="input" type="password" placeholder="Confirm your password">
                <div class="btn_block">
                    <button class="btn3" @click="createUser">Registration</button>
                    <RouterLink to="/login" class="login">Already have account?</RouterLink>
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
            user: {
                firstName: '',
                lastName: '',
                email: '',
                phoneNumber: '',
                password: '',
                confirmPassword: ''
            }
        }
    },
    methods: {
        createUser() {
            try {
                axios.post('https://localhost:7219/User', this.user)
                  .then((res) => {
                    localStorage.setItem('token', res.data.token);
                    localStorage.setItem('id', res.data.id);
                    router.push('/');
                  })
                  .catch((err) => console.log(err));                

                this.$emit('create', this.user);
                this.user = {
                    firstName: '',
                    lastName: '',
                    email: '',
                    phoneNumber: '',
                    password: '',
                    confirmPassword: ''
                }
            } catch (err) {
                console.log(err);
            }
        }
    }
}
</script>
  
<style>
.register_block {
    display: flex;
    justify-content: center;
}

.registerForm {
    display: flex;
    justify-content: center;
    margin-top: 20px;
    background: transparent;
    border: 2px solid rgba(255, 255, 255, 0.5);
    backdrop-filter: blur(15px);
    width: 400px;
    border-radius: 20px;
    padding-bottom: 30px;
    color: white;
}

.btn3 {
    font-size: 20px;
    background: none;
    color: white;
    border: 2px solid white;
    border-radius: 15px;
    padding: 5px 20px 5px 20px;
}

.btn3:hover {
    background: white;
    color: black;
}

.login {
    padding-left: 10px;
    padding-top: 8.9px;
    font-size: 18px;
}

.login:visited {
    color: gray;
}

.login:hover {
    color: white;
}

.input {
    width: 300px;
    border: 1px solid teal;
    padding: 10px 15px;
    margin-top: 15px;
}
</style>
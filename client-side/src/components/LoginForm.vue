<template>
    <div class="loginForm">
      <form @submit.prevent>
        <h4 class="h4">Log in</h4>
        <label>
          Email: <br />
        </label>
        <input class="input" v-model="user.email" type="text" placeholder="Your email address"> <br />
        <label>
          Password: <br />
        </label>
        <input class="input" v-model="user.password" type="password" placeholder="Your account password">
        <div class="btn_block">
          <button type="submit" @click="userLogin" class="btn2">Log in</button>
          <RouterLink :to="'/register'" class="register">No account?</RouterLink>
        </div>
      </form>
    </div>
  </template>
  
  <script>
  import router from '@/router';
  import axios from 'axios';
  export default {
    data() {
      return {
        user: {
          email: '',
          password: ''
        }
      }
    },
    methods: {
      userLogin() {
        try {
          axios.post('https://localhost:7219/Login', this.user)
            .then((res) => {
              localStorage.setItem('token', res.data.token);
              localStorage.setItem('id', res.data.id);
              router.push('/');
            });
          
          this.$emit('login', this.user);
          this.user = {
            email: '',
            password: ''
          }
        } catch (err) {
          console.log(err);
        }
      }
    }
  }
  </script>
  
  <style>
  .loginForm {
    background: transparent;
    backdrop-filter: blur(15px);
    display: flex;
    justify-content: center;
    justify-self: center;
    width: 400px;
    border-radius: 20px;
    margin-top: 120px;
    padding-bottom: 15px;
    border: 2px solid rgba(255, 255, 255, 0.5);
    border-radius: 20px;
    color: white;
  }
  .h4 {
    text-align: center;
  }
  .btn_block {
    margin-top: 20px;
    display: flex;
    justify-content: center;
  }
  .btn2 {
    font-size: 20px;
    background: none;
    color: white;
    border: 2px solid white;
    border-radius: 15px;
    padding: 3px 15px 3px 15px;
  }
  .register {
    text-align: center;
    padding-left: 10px;
    padding-top: 7.3px;
    font-size: 18px;
    color: lightgray;
  }
  .register:visited {
    color: lightgray;
  }
  .register:hover {
    color: white;
  }
  .btn2:hover {
    background: white;
    color: black;
  }
  .input {
    width: 300px;
    border-radius: 15px;
    padding: 10px 15px;
    margin-top: 15px;
    border: 2px solid teal;
  }
  </style>
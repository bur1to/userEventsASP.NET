<template>
    <div class="updateForm">
      <div class="update">
        <form @submit.prevent>
          <h4 style="text-align: center;">Edit profile</h4>
          <label>
            Username:
          </label>
          <input v-model="user.firstName" class="input" type="text" placeholder="First name">
          <input v-model="user.lastName" class="input" type="text" placeholder="Second name"><br />
          <label>
            Email:
          </label>
          <input v-model="user.email" class="input" type="email" placeholder="example@example.com"><br />
          <label>
            Phone number:
          </label>
          <input v-model="user.phoneNumber" class="input" type="text" placeholder="+(38) 111 111 1111"><br />
          <label>
            Password:
          </label>
          <input v-model="user.password" class="input" type="password" placeholder="Password"><br />
          <label>
            Confirm password:
          </label>
          <input v-model="user.confirmPassword" class="input" type="password" placeholder="Confirm password">
          <div style="margin-top: 15px;">
            <button type="submit" @click="updateUser" class="btn11">Edit</button>
          </div>
        </form>
      </div>
    </div>
  </template>
    
  <script>
  import axios from 'axios'
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
      updateUser() {
        try {
          axios.put(`https://localhost:7219/User/${localStorage.getItem('id')}`, this.user)
            .then((res) => console.log(res.data))
            .catch((err) => console.log(err));
        } catch (err) {
          console.log(err);
        }
      }
    }
  }
  </script>
    
  <style>
  .updateForm {
    display: flex;
    justify-content: center;
    color: white;
  }
  .btn11 {
    margin-top: 10px;
    font-size: 20px;
    border-radius: 15px;
    padding: 3px 11px 3px 11px;
    background: none;
    color: white;
    border: 2px solid white;
  }
  .btn11:hover {
    background: white;
    color: black;
  }
  .update {
    background: rgba(0, 0, 0, 0.3);
    border-radius: 20px;
    width: 400px;
    align-items: center;
    padding: 15px;
    display: flex;
    justify-content: center;
    border: 2px solid white;
  }
  form {
    display: flex;
    flex-direction: column;
  }
  .input {
    width: 300px;
    border: 1px solid teal;
    padding: 10px 15px;
    margin-top: 15px;
  }
  </style>
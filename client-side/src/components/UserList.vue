<template>
    <div class="users__block">
      <h3 class="h3">Users table:</h3>
      <div class="select">
        <strong>Show</strong>
        <my-select class="show" v-model="limit" :options="selectedNumber" />
        <strong class="show">users</strong>
        <strong>Sort:</strong>
        <my-select v-model="sort" :options="selectedOptions" />
      </div>
      <table class="table">
        <thead>
          <th>Username</th>
          <th>Email</th>
          <th>Phone Number</th>
          <th>Event Count</th>
          <th>Next Event Date</th>
        </thead>
        <tbody>
          <tr v-for="user in users" :key="user.id">
            <td>
              <RouterLink to="/profile" class="route_style">
                <a>
                  {{ `${user.firstName} ${user.lastName}` }}
                </a>
              </RouterLink>
            </td>
            <td>{{ user.email }}</td>
            <td>{{ user.phoneNumber }}</td>
            <td>
              <div class="deleteBlock">
                <button class="delete" @click="deleteUser(user.id)">Delete</button>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div class="page__wrapper">
      <div v-for="pageNumber in totalPages" :key="pageNumber" class="page" :class="{
        'current-page': page === pageNumber
      }" @click="changePage(pageNumber)">{{ pageNumber }}</div>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  import UpdateUserForm from '@/components/UpdateUserForm.vue'
  export default {
    components: {
      UpdateUserForm
    },
    data() {
      return {
        users: [],
        page: 1,
        limit: 5,
        sort: 'firstName',
        sortBy: 'asc',
        totalPages: 0,
        selectedOptions: [
          { value: 'firstName', name: 'First name' },
          { value: 'lastName', name: 'Last name' },
          { value: 'email', name: 'Email' }
        ],
        selectedNumber: [
          { value: this.limit, name: '5' },
          { value: this.limit, name: '10' },
          { value: this.limit, name: '15' }
        ],
        dialogVisible: false
      }
    },
    methods: {
      changePage(pageNumber) {
        try {
          this.page = pageNumber;
          // localStorage.page = this.page;
          this.getUsers({ page: pageNumber - 1 });
          // this.getUsers({ sort: this.sort});
          // this.getUsers({ limit: this.limit });
        } catch (err) {
          console.log(err);
        }
      },
      getUsers(params) {
        try {
          axios.get('https://localhost:7219/User', { params })
            .then((res) => this.users = res.data)
            .catch((err) => console.log(err));
          // this.totalPages = Math.ceil(data.count / this.limit);
        } catch (err) {
          console.log(err);
        }
      },
      deleteUser(id) {
        try {
          axios.delete(`https://localhost:7219/User/${id}`);
        } catch (err) {
          console.log(err);
        }
      },
      showDialog() {
        this.dialogVisible = true;
      }
    },
    mounted() {
      this.getUsers();
      // if (localStorage.page) {
      //   this.page = localStorage.page
      // }
    }
  }
  </script>
  
  <style>
  .users__block {
    font-size: 20px;
  }
  .h3 {
    text-align: center;
  }
  .table {
    border-collapse: collapse;
    border: 2px solid white;
    margin: auto;
  }
  thead {
    text-align: left;
  }
  th,
  td {
    border: 2px solid white;
    padding: 10px;
    min-width: 200px;
  }
  a {
    text-decoration: none;
  }
  a:visited {
    color: white;
  }
  .route_style {
    color: white;
  }
  .page__wrapper {
    display: flex;
    margin-top: 15px;
    justify-content: center;
  }
  .page {
    border: 1px solid white;
    padding: 8px;
    margin-right: 10px;
  }
  .current-page {
    border: 2.5px solid white;
  }
  .select {
    display: flex;
    justify-content: center;
    margin-bottom: 15px;
  }
  .deleteBlock {
    display: flex;
    justify-content: center;
  }
  .delete {
    font-size: 20px;
    background: none;
    color: white;
    border: 2px solid white;
    border-radius: 15px;
    padding: 3px 11px 3px 11px
  }
  .delete:hover {
    background: white;
    color: black;
  }
  .show {
    margin-right: 10px;
  }
  </style>
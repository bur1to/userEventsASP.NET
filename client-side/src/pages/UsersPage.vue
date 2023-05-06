<template>
    <div class="users">
        <h1>All users</h1>
        <UserList />
    </div>
</template>
  
<script>
import UserList from '@/components/UserList.vue';
export default {
    components: {
        UserList
    },
    data() {
        return {
            users: [],
            dialogVisible: false
        }
    },
    methods: {
        createUser(user) {
            this.users.push(user);
            this.dialogVisible = false;
        }
    }
}
</script>
  
<style>
.users {
    background: rgba(0, 0, 0, 0.5);
    height: auto;
    padding: 20px;
    margin-top: 15px;
    color: white;
    border: 2px solid white;
    border-radius: 20px;
}
</style>
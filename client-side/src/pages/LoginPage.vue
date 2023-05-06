<template>
    <div class="login">
        <LoginForm />
    </div>
</template>

<script>
import LoginForm from '@/components/LoginForm.vue'
export default {
    components: {
        LoginForm
    }
}
</script>

<style>
.login {
    display: flex;
    justify-content: center;
}
</style>
<template>
    <h2 class="text-center page-heading">Login</h2>
    <section class="container">
        <div class="form-group">
            <label for="tbxUsername">Username</label>
            <input v-model="username" type="text" class="form-control" name="tbxUsername" id="tbxUsername" aria-describedby="lblUsername" placeholder="Username">
            <small id="lblUsername" class="form-text text-muted">Please enter your Username</small>
        </div>
        <div class="form-group">
            <label for="tbxPassword">Password</label>
            <input v-model="password" type="password" class="form-control" name="tbxPassword" id="tbxPassword" placeholder="Password">
        </div>
        <button @click="submit" type="submit" class="btn btn-primary">Login</button>
    </section>
</template>
<script lang="js">
import router from '@/helpers/router';

export default {
    data() {
        return {
            username: '',
            password: ''
        }
    },
    methods: {
        submit() {
            if (this.username == 'takerman' && this.password == 'Hakerman91!') {
                router.push('/home');
            }
        }
    }
}
</script>
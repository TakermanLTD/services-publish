<template>
    <nav class="navbar navbar-dark bg-dark navbar-expand-lg">
        <div class="container">
            <router-link class="navbar-brand" to="/home">PUBLISHER</router-link>
            <button class="navbar-toggler d-lg-none" type="button" data-toggle="collapse" data-target="#navigation" aria-controls="navigation"
                    aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navigation">
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                    <li class="nav-item active">
                        <router-link class="nav-link" to="/home">Home</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/admin">Admin</router-link>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
</template>
<script lang="js">
export default {
    data() {
        return {
        }
    }
}
</script>
<template>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <router-link to="/home" class="navbar-brand">PUBLISHER</router-link>
        <ul class="navbar-nav">
            <li class="nav-item">
                <router-link to="/home" class="nav-link">Home</router-link>
            </li>
            <li class="nav-item">
                <router-link to="/admin/platform-links" class="nav-link">Platform Links</router-link>
            </li>
        </ul>
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
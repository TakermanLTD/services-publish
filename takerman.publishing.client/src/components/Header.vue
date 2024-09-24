<template>
    <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
        <router-link :to="this.isAuthenticated ? '/home' : '/login'" class="navbar-brand">PUBLISHER</router-link>
        <ul v-if="!this.isAuthenticated && !this.isLoading" class="navbar-nav">
            <li class="nav-item">
                <button id="qsLoginBtn" class="btn btn-primary btn-margin" @click.prevent="login">Login</button>
            </li>
        </ul>
        <ul v-if="this.isAuthenticated" class="navbar-nav">
            <li class="nav-item">
                <router-link to="/dashboard" class="nav-link">Dashboard</router-link>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarAdmin" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Admin
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarAdmin">
                    <li>
                        <router-link to="/admin/projects" class="dropdown-item">Projects</router-link>
                    </li>
                    <li>
                        <router-link to="/admin/project-secrets" class="dropdown-item">Project Secrets</router-link>
                    </li>
                </ul>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarSuperAdmin" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Super Admin
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarSuperAdmin">
                    <li>
                        <router-link to="/super-admin/platforms" class="dropdown-item">Platforms</router-link>
                    </li>
                    <li>
                        <router-link to="/super-admin/platform-links" class="dropdown-item">Platform Links</router-link>
                    </li>
                    <li>
                        <router-link to="/super-admin/platform-secrets" class="dropdown-item">Platform Secrets</router-link>
                    </li>
                    <li>
                        <router-link to="/super-admin/platform-post-types" class="dropdown-item">Platform Post Types</router-link>
                    </li>
                    <li>
                        <router-link to="/super-admin/post-types" class="dropdown-item">Post Types</router-link>
                    </li>
                </ul>
            </li>
            <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarProfile" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <img :src="this.user.picture" alt="User's profile picture" class="nav-user-profile rounded-circle" width="30" />
                </a>
                <ul class="dropdown-menu" aria-labelledby="navbarProfile">
                    <li>
                        <div class="dropdown-header">{{ this.user.name }}</div>
                        <router-link to="/profile" class="dropdown-item">
                            Profile
                        </router-link>
                    </li>
                    <li>
                        <a href="#" class="dropdown-item" @click="logout()">
                            Log out
                        </a>
                    </li>
                </ul>
            </li>
        </ul>
    </nav>
</template>
<script lang="js">
export default {
    data() {
        return {
            isAuthenticated: this.$auth0.isAuthenticated,
            isLoading: this.$auth0.isLoading,
            user: this.$auth0.user
        }
    },
    methods: {
        login() {
            this.$auth0.loginWithRedirect();
        },
        logout() {
            this.$auth0.logout({
                logoutParams: {
                    returnTo: window.location.origin
                }
            });
        }
    }
}
</script>
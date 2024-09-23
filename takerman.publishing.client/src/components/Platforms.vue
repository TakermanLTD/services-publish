<template>
    <div class="accordion" id="accordionPublications">
        <div class="accordion-item">
            <h2 class="accordion-header" id="accordeonPublications">
                <button class="accordion-button text-center" type="button" data-bs-toggle="collapse" data-bs-target="#collapsePublications" aria-expanded="true" aria-controls="collapsePublications">
                    Platforms
                </button>
            </h2>
            <div id="collapsePublications" class="accordion-collapse collapse show" aria-labelledby="accordeonPublications" data-bs-parent="#accordionPublications">
                <div class="accordion-body">
                    <div class="list-group">
                        <label v-for="(platform, index) in this.platforms" :key="index" :id="'secret' + platform.id" class="list-group-item">
                            <input class="form-check-input me-1" type="checkbox" :value="platform.id" />
                            {{ platform.name }}
                        </label>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="js">
export default {
    data() {
        return {
            platforms: []
        }
    },
    async mounted() {
        this.platforms = await (await fetch('/ProjectSecrets/GetAll?projectId=' + this.project)).json();
    },
    props: {
        project: Number,
        projects: Object
    }
}
</script>
<template>
    <div class="row">
        <div class="table-responsive">
            <table class="table table">
                <thead>
                    <tr class="table-primary">
                        <th>
                            <label class="form-label text-center" for="ddlPlatform">Platform</label>
                            <select @change="this.refresh()" v-model="selectedPlatform" class="form-select" id="ddlPlatform">
                                <option v-for="(platform, index) in platforms" :key="index" :value="platform.id">{{ platform.name }}</option>
                            </select>
                        </th>
                        <th>
                            <button @click="save" type="button" class="btn btn-success">
                                <i class="fa-solid fa-save"></i>
                            </button>
                        </th>
                    </tr>
                    <tr class="table-primary">
                        <th scope="col">Name</th>
                        <th scope="col">Allowed</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(postType, index) in this.postTypes" :key="index">
                        <td>{{ postType.name }}</td>
                        <td>
                            <input type="checkbox" :id="'platformPostType' + postType.id" :value="postType.id" @change="refreshSelected" class="form-check-input platform-post-type" :checked="hasPlatformPostType(postType.id)" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
export default {
    data() {
        return {
            postTypes: [],
            platforms: [],
            platformPostTypes: [],
            selectedPlatform: 0,
            selectedPostTypes: []
        }
    },
    async mounted() {
        this.platforms = await (await fetch('/Platforms/GetAll')).json();
        if (this.platforms && this.platforms.length > 0) {
            this.selectedPlatform = this.platforms[0].id;
        }
        this.postTypes = await (await fetch('/PostTypes/GetAll')).json();
        this.platformPostTypes = await (await fetch('/PlatformPostTypes/GetAll?platformId=' + this.selectedPlatform)).json();
        for (let i = 0; i < this.platformPostTypes.length; i++) {
            const platformPostType = this.platformPostTypes[i];
            const existing = document.getElementById('platformPostType' + platformPostType.postTypeId);
            if (existing) {
                existing.checked = true;
            }
        }
    },
    methods: {
        refreshSelected() {
            this.selectedPostTypes = [];
            var checked = document.querySelectorAll('.platform-post-type:checked');
            for (let index = 0; index < checked.length; index++) {
                const element = checked[index];
                this.selectedPostTypes.push(Number(element.value));
            }
        },
        hasPlatformPostType(postTypeId) {
            for (let i = 0; i < this.platformPostTypes.length; i++) {
                const platformPostType = this.platformPostTypes[i];
                if (platformPostType.postTypeId == postTypeId) {
                    return true;
                }
            }
            return false;
        },
        async save() {
            this.selectedPostTypes = await (await fetch('/PlatformPostTypes/Update', {
                method: "PUT",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    platformId: this.selectedPlatform,
                    postTypes: this.selectedPostTypes
                })
            })).json();
        }
    }
}
</script>
<template>
    <div>
        <hgroup>
            <h3 class="text-center">Short</h3>
        </hgroup>
        <div class="form-group">
            <label for="postDescription">Description</label>
            <textarea id="postDescription" class="form-control" placeholder="Description" aria-describedby="postDescription" v-model="postDescription"></textarea>
        </div>
        <br />
        <div class="custom-file mt-3 mb-3">
            <input type="file" class="custom-file-input" id="short" style="border: 1px solid black" />
        </div>
        <button @click="publish" class="btn btn-primary text-center">Publish</button>
    </div>
</template>
<script lang="js">
export default {
    data() {
        return {
            postDescription: '',
            postShort: []
        }
    },
    methods: {
        async publish() {
            let platforms = []; 
            let platfromsDom = document.querySelectorAll('.platform:checked');
            for(let i = 0; i < platfromsDom.length; i++) {
                platforms.push(Number(platfromsDom[i].value));
            }
            const data = JSON.stringify({
                ProjectId: Number(document.getElementById('ddlProject').value),
                Type: Number(document.getElementById('ddlPostType').value),
                Platforms: platforms,
                Description: this.postDescription,
                Short: this.postShort
            });
            const requestOptions = {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: data
            };
            const result = await fetch('Publish/PublishShort', requestOptions);
        }
    }
}
</script>